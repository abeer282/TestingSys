function getWorkers(){
	    fetch("https://localhost:44324/api/Workers")
    .then(response => response.json())
    .then(function(data){
		console.log(data);
		var i;
		for(i=0;i<data.length;i++){
			addWorker('tablebody', data[i]);
		}
    }).catch(function(error) { 
		console.error('Unable to get workers.', error)
		document.getElementById("result").innerHTML = 'Unable to get workers.';
	});
}

function addWorker(tablebody,worker) {
	let did_test,pass;
	if(worker.did_test){
		did_test="\u05DB\u05DF";
		if(worker.pass_test)
			pass="\u05DB\u05DF";
		else
			pass="\u05DC\u05D0";
	}else{
		did_test="\u05DC\u05D0";
		pass="-";
	}
	
	document.getElementById(tablebody).innerHTML+="<tr> <td>"+worker.id+"</td> <td>"+worker.fname+" "+worker.lname+"</td> <td>"+worker.email+"</td> <td>"+did_test+"</td> <td>"+pass+"</td> </tr>";
}
