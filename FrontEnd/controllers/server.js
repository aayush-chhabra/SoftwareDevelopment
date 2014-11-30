var express = require('express');
var app = express();
var http = require('http');
var server = http.createServer(app);
var io = require('socket.io').listen(server);

io.sockets.on('connection',function(client){
	console.log('Client connected from address ' , client.handshake.address);	
	client.emit('messages',{hello:'Welcome to the ChatApp'});
	client.on('message',function(data){
		client.broadcast.emit("messageFromClient",data);
		console.log(data);
	});
});
app.use(express.static(__dirname + '/public'));

server.listen(8080,function(){
	console.log("Listening on 8080");
});