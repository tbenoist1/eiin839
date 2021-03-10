document.getElementById("workingTest").innerHTML="It works";
contrats = [];
key = "fd8a1c81d81337532f88e746a545e0721fe29ccc";
function recupererContrats() {
    var url = "https://api.jcdecaux.com/vls/v3/contracts?apiKey=" + document.getElementById("apiKey").value;
    var requete = "GET";

    var caller = new XMLHttpRequest();
    caller.open(requete, url, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader ("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload=ajouterOptions;

    caller.send();
}
function ajouterOptions() {
	// Let's parse the response:
    var response = JSON.parse(this.responseText);
    // console.log(response);
	var options = '';
    response.forEach(contract => {
		this.contrats += contract.name
		options += '<option value="' + contract.name + '" />';
    });
	document.getElementById("datalist-contrats").innerHTML = options
}
function parserReponse() {
    var response = JSON.parse(this.responseText);
    console.log(response);	
}
function recupererStationsParContrat(){
	contrat = document.getElementById("input-contrats").value
	key = document.getElementById("apiKey").value
	var url = "https://api.jcdecaux.com/vls/v1/stations?contract="+contrat+"&apiKey="+key; 
	var requete = "GET";

    var caller = new XMLHttpRequest();
    caller.open(requete, url, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader ("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload=parserReponse;

    caller.send();
}
	