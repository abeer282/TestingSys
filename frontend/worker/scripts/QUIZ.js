var testUrl = "https://localhost:44324/api/Tests"
var questionUrl = "https://localhost:44324/api/Questions/exam"
var scoreUrl = "https://localhost:44324/api/Questions/score"
var currentQuestion=0;
var questionsnums = [];
let questions =[];
var answers = [];
var score;
var numOfPass;

//var container=document.getElementById('quizContainer');
var questionEl=document.getElementById('question');
var opt1 = document.getElementById('opt1');
var opt2 = document.getElementById('opt2');
var opt3 = document.getElementById('opt3');
var opt4 = document.getElementById('opt4');

var nextButton=document.getElementById('nextButton');
var prevButton=document.getElementById('prevButton');
var resultCont=document.getElementById('result');


function getTest(){
	    fetch(testUrl)
    .then(response => response.json())
    .then(function(data){
		setQuestionsNumbers(data[0].questions);
		setNumOfPass(data[0].pass_questions_number);
		loadQuestion(currentQuestion);
    }).catch(function(error) { 
		console.error('Unable to get exam.', error);
	});
}

function setQuestionsNumbers(str){
	questionsnums=str.split('#');
	questionsnums.pop();
	var i;
	for(i=0;i<questionsnums.length;i++)
			answers.push("0");
}

function setNumOfPass(pass){
	numOfPass=pass;
}

function loadQuestion(questionIndex){ 
	fetch(questionUrl+"/"+questionsnums[questionIndex])
    .then(response => response.json())
    .then(function(data){
		questions.push(data);
		var q = questions[questionIndex];
		document.getElementById('question').innerHTML=data.question;
		document.getElementById('opt1').innerHTML=data.answer1;
		document.getElementById('opt2').innerHTML=data.answer2;
		document.getElementById('opt3').innerHTML=data.answer3;
		document.getElementById('opt4').innerHTML=data.answer4;
    }).catch(function(error) { 
		console.error('Unable to get questions.', error);
	});
};

function loadNextQuestion(){
    var selectedOption= document.querySelector('input[name=option]:checked');
        if(!selectedOption){
        alert('Please Select Your Answer');
        return;
    }
	
    answers[currentQuestion]=selectedOption.value;
	
    selectedOption.checked=false;
	
    currentQuestion++;
	
    if(currentQuestion==questionsnums.length-1){
		document.getElementById('nextButton').innerHTML='סיים';
    }
    if(currentQuestion==questionsnums.length){
		getScore();
		//window.close('','_parent','');
		//var numOfPassObj = { numOfP : numOfPass};
		//var answersObj = { answersArr : answers};
		//sessionStorage.setItem("numOfPass", JSON.stringify(numOfPassObj));
		//sessionStorage.setItem("answers", JSON.stringify(answers));
		//sessionStorage.setItem("questions", JSON.stringify(questions));
		//window.location.href = "score.html";
		//location.replace("score.html");
        //document.getElementById('quizContainer').style.display= "none";
        //document.getElementById('result').style.display="block";
        //document.getElementById('result').innerHTML='עברת את המבחן ' + score;
        return;
    }
    loadQuestion(currentQuestion);
};  


function setScore(){
	//numOfPass=sessionStorage.getItem("numOfPass");
	//answers=sessionStorage.getItem("answers");
	//questions=sessionStorage.getItem("questions");
	//console.log('numOfPass\n'+numOfPass);
	//console.log('answers\n'+answers);
	//console.log('questions\n'+questions);
	//answers
	//getScore();
	//document.getElementById('score').innerHTML='עברת את המבחן ';
	//console.log('aaaaaaaaaaaaaaaaaaa');
}

function getScore(){
	var q='',a='',i;
	for(i=0;i<questionsnums.length;i++){
		q = q + questionsnums[i]+'-';
		a = a + answers[i];
	}
	var data = ''+numOfPass+'-'+q+'-'+a;
	fetch(scoreUrl + '/' + data)
    .then(response => response.json())
    .then(function(res){
		score=Boolean(res.result);
		
		if (score){
			alert("יווהווו, עברת את המבחן!!");
			
		}else{
			alert("הארד לאק, לא עברת!!");
			
		}
    }).catch(function(error) { 
		console.error('Unable to get score.', error);
	});
}

