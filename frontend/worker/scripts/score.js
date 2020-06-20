var workersUrl = "https://localhost:44324/api/Workers";
var workerId;
var fname;
var lname;
var email;
var result;

function setResult(){
	workerId = localStorage.getItem("WorkerId");
	localStorage.removeItem("WorkerId");
	result = localStorage.getItem("score");
	localStorage.removeItem("score");
	fname = localStorage.getItem("WorkerFname");
	lname = localStorage.getItem("WorkerLname");
	email = localStorage.getItem("WorkerEmail");
	localStorage.removeItem("WorkerFname");
	localStorage.removeItem("WorkerLname");
	localStorage.removeItem("WorkerEmail");
	if(result){
		document.getElementById('score').innerHTML='Yoo hoo!! you passed :)';//when hebrew gets strange letters
	}else{
		document.getElementById('score').innerHTML='Hard luck!! you failed :/';//when hebrew gets strange letters
	}
	//sendResult();
}


