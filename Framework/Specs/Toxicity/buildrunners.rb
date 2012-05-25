class NUnitRunner
    include FileTest

    def initialize(paths)
        compile_platform = paths.fetch(:platform, 'x86')
        @results_dir = paths[:resultsdir]
        Dir.mkdir @results_dir unless exists?(@results_dir)
        test_results = File.join(@results_dir, 'test-results.xml')
        nunit_exe_path = paths.fetch(:exe_path, 'tools/NUnit-EXE/')
        @nunit_exe = File.join(nunit_exe_path, "nunit-console-#{compile_platform}.exe /noshadow /nothread /xml:#{test_results}")
	end

    def execute(assemblies)
        assemblies.each do |assem|
			sh "#{@nunit_exe} #{assem}"
		end
    end
end

class MSBuildRunner
    def self.compile(attributes)
        clr_version = attributes[:clrversion]
        compile_target = attributes[:compilemode]
        solution_file = attributes[:solutionfile]

		framework_directory = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', clr_version)
        msbuild_file = File.join(framework_directory, 'msbuild.exe')

        sh "#{msbuild_file} #{solution_file} /nologo /maxcpucount /v:m /property:BuildInParallel=false /property:Configuration=#{compile_target} /t:Rebuild"
    end
end

class ToxicityRunner
    def initialize(paths)
        @compile_target = paths[:compilemode]
        @build_directory = paths[:builddirectory]
        results_dir = paths[:resultsdir]
        Dir.mkdir results_dir unless exists?(results_dir)
        @code_metrics_report = File.join(results_dir, 'toxicity-report.xml')
    end

    def calculate_metrics
        sh "tools/Reflector/Reflector.exe /Run:Reflector.CodeMetrics /OutputPath:\"#{@code_metrics_report}\" /configuration:\"./tools/Reflector/reflector-#{@compile_target}.config\" /Assembly:\"#{@build_directory}/Toxicity.exe\" /Assembly:\"#{@build_directory}/GoogleChartSharp.dll\""
    end

    def create_report
        toxicity_exe = File.join(@build_directory, 'Toxicity.exe')
        sh "#{toxicity_exe} #{@code_metrics_report}"
    end
end
