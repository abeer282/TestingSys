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
	sendResult();
}

function sendResult(){
	
	var myHeaders = new Headers();
	myHeaders.append("Content-Type", "application/json");

	var raw = JSON.stringify({"id":workerId,"fname":fname,"lname":lname,"email":email,"did_test":true,"pass_test":result});

	var requestOptions = {
	  method: 'PUT',
	  headers: myHeaders,
	  body: raw,
	  redirect: 'follow'
	};

	fetch(workersUrl+'/'+workerId, requestOptions)
	  .then(response => response.text())
	  .then(res => console.log(res))
	  .catch(error => console.log('Unable to set result!', error));
}
