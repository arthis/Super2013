
function subscribeEvents(connection, sockets) {
    function subscribeEvent(queue, event) {
        // Create a queue and bind to all messages.
        connection.queue(queue, function (q) {
            // Catch messages defined in exchange
            q.bind(event, event);

            // Receive messages
            q.subscribe(function (message) {
                // Print messages to stdout  
//                var buff = new Buffer(message,'binary');
//                var msgJson = buff.toString('utf8');
                console.log('--------------------------------------------------------');
//                console.log(msgJson);
//                console.log('--------------------------------------------------------');
                for (var i = 0; i < sockets.length; i++) {
                    console.log('_sockets[' + i + '] emitted');
                    sockets[i].emit(event, message);
                }
            });
        });
    }

    subscribeEvent('Events_AreaIntervento_AreaInterventoCreata:Events_Super', 'Events_AreaIntervento_AreaInterventoCreata:Events');
}

exports.subscribeEvents = subscribeEvents;