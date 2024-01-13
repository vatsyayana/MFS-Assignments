function validateForm(e){
    e.preventDefault();

    var inputs=document.getElementsByTagName("input");
    for(var i=0;i<inputs.length;i++){
        if(inputs[i].value==""){
            alert("Fill out "+inputs[i].name);
            break;
        }
        if(inputs[i].type=="tel"){
            if(inputs[i].value.length!=10){
                alert("Mobile No. should be of 10 digits only");
            }
        }
        // if(inputs[i].type=="mail" && !(/^[A-Za-z0-9._-]+@+[a-z]+.+[a-z]$/).test(inputs[i].value)){
    //     alert("Enter a valid email addresss");
    //     break;
    // }
    }

    var gender=document.querySelector('input[name="txtGender"]:checked');
    if(!gender){
        alert("Please choose a gender");
    }
    
    var dropdowns=getElementByTagName("select");
    for(var i=0;i<dropdowns.length;i++){
        if(dropdown[i].value=="select"){
            alert("Choose a country");
        }
    }
}