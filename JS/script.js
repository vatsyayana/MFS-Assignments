function validateForm(e){
    e.preventDefault();

    var inputs=document.querySelector("labelInputPair[]");
    var gender=document.querySelector('input[name="txtGender"]:checked');
    var today=new Date();

    for(var i=0;i<inputs.length;i++){
        debugger
        if(inputs[i].value=="" && inputs[i].className=="requiredInput"){
            alert("Fill out "+inputs[i].name);
            break;
        }

        if((inputs[i].id).includes("Name") && !((/([A-Za-z]+( [A-Za-z]+)+)*/i).test(inputs[i].value))){
            alert(inputs[i].id+" should not contain numbers");
            break;
        }

        if(inputs[i].name=="txtGender" && !gender){
            alert("Please choose a gender");
            break;
        }

        if(inputs[i].type=="date" && (dateDOB>today)){
            alert("D. O. B. should not be a future date");
            break;
        }

        if(inputs[i].type=="tel" && inputs[i].value!="" && !((/^\+\d{1,3}-\d{9,10}$/).test(inputs[i].value))){
            alert("Mobile No. should be in proper format with the applicable country code. For eg, +xxx-xxxxxxxxxx.");
            break;
        }

        if(inputs[i].id=="txtEmail" && !((/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/).test(inputs[i].value))){
            alert("Enter a valid email addresss");
            break;
        }

        // if(inputs[i].)
    }

    var dropdowns=document.getElementsByTagName("select");
    for(var i=0;i<dropdowns.length;i++){
        if(dropdowns[i].value==""){
            alert("Please choose a "+dropdowns[i].name);
            break;
        }
    }
}

function calculateAge(){
    var DOB=document.getElementById("dateDOB").value;
    var dateDOB=new Date(DOB);
    var today=new Date();
    var diffTime=Math.abs(today-dateDOB);
    var txtAge=Math.floor(diffTime/(1000*60*60*24*365.25));
    document.getElementById("txtAge").value=txtAge;
}

function checkAge(){
    var DOB=document.getElementById("dateDOB").value;
    var dateDOB=new Date(DOB);
    var today=new Date();
    var diffTime=Math.abs(today-dateDOB);
    var txtAge=Math.floor(diffTime/(1000*60*60*24*365.25));
    if(document.getElementById("txtAge").value!=txtAge){
        document.getElementById("txtAge").value=txtAge;
    }
}

// function copyPresentAddressToPermanentAddress(){
//     var presentAddress=document.getElementsByClassName("presentAddress");
//     for(var i=0;i<presentAddress.length;i++){
//         document.getElementsByClassName("permanentAddress")[i].value=presentAddress[i].value;
//     }
// }

    // var countryObject={"India": ["Bihar","J&K"],"USA": ["New York","Los Angeles"]};
    // window.onload=function(){
    //     debugger
    //     var presentCountrySelect=document.getElementById("txtPresentCountry");
    //     var presentStateSelect=document.getElementById("txtPresentState");
    //     // var permanentCountrySelect=document.getElementById("txtPermanentCountry");
    //     // var permanentStateSelect=document.getElementById("txtPermanentState");
    //     for(var x in countryObject){
    //         presentCountrySelect.options[presentCountrySelect.options.length]=new Option(x,x);
    //     }
    //     presentCountrySelect.onchange=function(){
    //         presentStateSelect.length=1;
    //         for(var y in countryObject[this.value]){
    //             presentStateSelect.options[presentStateSelect.options.length]=new Option(y,y);
    //         }
    //     }
    // }