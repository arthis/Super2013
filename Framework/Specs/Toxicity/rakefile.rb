include FileTest
require 'buildrunners.rb'
require 'rubygems'

RESULTS_DIRECTORY = "results"
COMPILE_TARGET ="Debug"

BUILD_DIRECTORY = "Toxicity/bin/#{COMPILE_TARGET}"
TEST_DIRECTORY = "Toxicity.Test/bin/#{COMPILE_TARGET}"

private
def files_from_test_like(pattern)
  Dir.glob File.join("**/bin/#{COMPILE_TARGET}", pattern)
end

task :default => [:test]

task :all => [:test, :toxicity]

task :clean do
  rm_rf [BUILD_DIRECTORY, TEST_DIRECTORY, RESULTS_DIRECTORY]
end

task :compile => [:clean] do
  MSBuildRunner.compile :compilemode => COMPILE_TARGET, :solutionfile => 'Toxicity.sln', :clrversion => 'v3.5'
end

task :test => [:compile] do
  test_runner = NUnitRunner.new :compilemode => COMPILE_TARGET, :resultsdir => RESULTS_DIRECTORY
  test_runner.execute files_from_test_like('*Test.dll')
end

# dogfooding
task :toxicity => [:compile] do
  toxicity_runner = ToxicityRunner.new :compilemode => COMPILE_TARGET, :resultsdir => RESULTS_DIRECTORY, :builddirectory => BUILD_DIRECTORY
  toxicity_runner.calculate_metrics
  toxicity_runner.create_report
end
