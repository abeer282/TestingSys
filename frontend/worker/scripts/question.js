var testUrl = "https://localhost:44324/api/Tests"
var questionUrl = "https://localhost:44324/api/Questions"
let questions =[];
let currentQuestion=0;


function getTest(){
	    fetch(testUrl)
    .then(response => response.json())
    .then(function(data){
		setQuestionsNumbers(data[0].questions);
		loadQuestion(currentQuestion);
		currentQuestion++;
    }).catch(function(error) { 
		console.error('Unable to get exam.', error);
	});
}

function setQuestionsNumbers(str){
	questions=str.split('#');
	questions.pop();
}
function loadQuestion(curr){
	 fetch(questionUrl+"/"+questions[curr])
    .then(response => response.json())
    .then(function(data){
		console.log(data);
		document.getElementById('question').innerHTML=data.question;
		document.getElementById('opt1').innerHTML=data.answer1;
		document.getElementById('opt2').innerHTML=data.answer2;
		document.getElementById('opt3').innerHTML=data.answer3;
		document.getElementById('opt4').innerHTML=data.answer4;
    }).catch(function(error) { 
		console.error('Unable to get exam.', error);
		
	});
	
}
function loadNextQuestion(){
	loadQuestion(currentQuestion);
	currentQuestion++;
}
function endTest(){
	alert("Working on that");
}