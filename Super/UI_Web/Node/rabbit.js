var http = require('http');
http.createServer(function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/html' });
    res.write('<html><head><link href="/Content/Site.css" rel="stylesheet" /></head><body>');
    res.write('<h1>Are you still there?</h1>');
    res.write('<p>');
    res.write('We are pleased that you made it through the final challenge where we pretended we were going to murder you. We are very very happy for your success. ');
    res.write('We are throwing a party in honor of your tremendous success. Place the device on the ground, then lie on your stomach with your arms at your sides. ');
    res.write('A party associate will arrive shortly to collect you for your party. Make no further attempt to leave the testing area. ');
    res.write('</p>');
    res.write('<p>');
    res.write("Proceed to test chamber " + process.env.PORT);
    res.write('</p>');
    res.end('</body></html>');
}).listen(process.env.PORT);

var amqp = require('amqp');

var connection = amqp.createConnection({ host: 'localhost',
                                         port: 5672,
                                         login: 'yoann',
                                         password: 'yogolo49',
                                         vhost: '/'
                                         });

// Wait for connection to become established.
connection.on('ready', function () {
    // Create a queue and bind to all messages.
    connection.queue('Events_AreaIntervento_AreaInterventoCreata:Events_Super', function (q) {
        // Catch all messages
        q.bind('Events_AreaIntervento_AreaInterventoCreata:Events', 'Events_AreaIntervento_AreaInterventoCreata:Events');

        // Receive messages
        q.subscribe(function (message) {
            // Print messages to stdout
            console.log('--------------------------------------------------------');
        });
    });
});