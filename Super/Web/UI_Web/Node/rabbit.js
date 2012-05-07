var app = require('http').createServer(handler)
  , io = require('socket.io').listen(app)
  , fs = require('fs')

app.listen(8091);

function handler(req, res) {
}

var amqp = require('amqp');

var sockets = [];

var events = require('./lib/modules/events')

var connection = amqp.createConnection({ host: 'localhost',
    port: 5672,
    login: 'yoann',
    password: 'yogolo49',
    vhost: '/'
});

// Wait for connection to become established.
connection.on('ready', function () {
    events.subscribeEvents(connection, sockets);
});

io.sockets.on('connection', function (socket) {
    sockets.push(socket);
});

