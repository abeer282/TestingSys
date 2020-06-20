var workersUrl = "https://localhost:44324/api/Workers";
var id;

function validate(){
	id=document.getElementById("idinput").value;
	isUser();
}

function isUser(){
	fetch(workersUrl+'/'+id)
    .then(response => {
		if (response.ok) {
			response.json().then(json => {
				if (typeof(Storage) !== "undefined") {
					localStorage.setItem("WorkerId", id);
					localStorage.setItem("WorkerFname", json.fname);
					localStorage.setItem("WorkerLname", json.lname);
					localStorage.setItem("WorkerEmail", json.email);
					window.location.replace("quiz.html");
				} else {
					alert("Sorry, your browser does not support Web Storage...");
				}
			});
		}else{
			window.location.replace ( 'error.html');
		}
	}).catch(function(error) { 
		console.error('Unable to get worker.', error);
		alert("כנראה יש תקלה בהתחברות לשרת, נסה שנית מאוחר יותר!");
	});
}
