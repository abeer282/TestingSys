var questionUrl = "https://localhost:44324/api/Questions"
function AddQuestion() {
	var id;
	//get values from input
	var question=document.getElementById("field1").value;
	var ans1=document.getElementById("field2").value;
	var ans2=document.getElementById("field3").value;
	var ans3=document.getElementById("field4").value;
	var ans4=document.getElementById("field5").value;
	var trueAns=document.getElementById("field6").value;
	
	
	//random or according according to the order in DB
	//setId();//async not good for now -_- 
	id=Math.floor(Math.random() * 10000);
	
	
	//prepare object
	var obj = {"id":id,"question":question,"answer1":ans1,"answer2":ans2,"answer3":ans3,"answer4":ans4,"true_answer":trueAns}
	
	
	//send to server
	var myHeaders = new Headers();
	myHeaders.append("Content-Type", "application/json");

	var raw = JSON.stringify(obj);

	var requestOptions = {
	  method: 'POST',
	  headers: myHeaders,
	  body: raw,
	  redirect: 'follow'
	};

	fetch(questionUrl, requestOptions)
	  .then(response => response.text())
	  .then(result => console.log(result))
	  .catch(error => console.log('error', error));
	
    
}

function setId(){
		fetch(questionUrl)
    .then(response => response.json())
    .then(function(data){
		console.log(data);
		console.log(data.length);
		id=data.length;
    }).catch(function(error) { 
		console.error('Unable to get questions.', error);
	});
}

//const setId_ = async () => {
  //  const response = await fetch(questionUrl);
    //const json = await response.json();
   // console.log(json.length);
	//id=json.length;
	//console.log(id);
//}
