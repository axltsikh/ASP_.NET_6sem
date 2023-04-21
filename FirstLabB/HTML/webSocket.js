var webSocket=null
var output
var startButton
var stopButton

window.onload = function(){
    if(Modernizr.websockets){
        console.log("Websockets working");
        output=document.getElementById('output')
        startButton = document.getElementById("start")
        stopButton=document.getElementById("stop")
        stopButton.disabled=true
    }
}

function Start(){
    if(webSocket==null){
        webSocket = new WebSocket('ws://localhost/FirstLabB/somepath.websocket');
        webSocket.onopen=function(){
            output.innerHTML += '\n' + "Сокет открыт"
        }
        webSocket.onclose = function(event){
            console.log("Closed success:");
            console.log(event)
        }
        webSocket.onmessage = function(evt){
            output.innerHTML += '\n' + evt.data
        }
        startButton.disabled=true
        stopButton.disabled=false
    }
}
function Stop(){
    output.innerHTML += '\n' + "Сокет закрыт"
    webSocket.close(1000,"Client closed connection");
    webSocket=null;
    startButton.disabled=false
    stopButton.disabled=true
}
