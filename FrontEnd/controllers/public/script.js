			var socket  = io.connect();
			var nickname = "anonymous";
			socket.on('messages',function(data){
				nickname = prompt("Enter your nickname : "); 
				if(nickname != "anonymous")
				{
					alert(data.hello + " " + nickname);
				}
			});

			socket.on('messageFromClient',function(data){ 
				var append = document.getElementById('inputArea').innerHTML;
				append = append + "</br>" + data;
				document.getElementById('inputArea').innerHTML = append;
				document.getElementById('textBox').value = '';
			});

			var emitmessage = function(){
				var message = nickname + " : " + document.getElementById('textBox').value;
				socket.emit('message',message);
				var append = document.getElementById('inputArea').innerHTML;
				append = append + "</br>" + message;
				document.getElementById('inputArea').innerHTML = append;
				document.getElementById('textBox').value = '';
			};

			var handlekeyPress = function(e)	{
				var keyCode = e.keyCode || e.which;
				if(keyCode==13)
				{
					emitmessage();
				}
			};