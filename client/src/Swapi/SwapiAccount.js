


export async function IsAutorize(){
    debugger
    let state;
    let response = await fetch('http://localhost:5000/api/Account/IsAuoturize', {
        method: 'Post'
    })
        .then(function(response) {
            return response.json();
            })
        .then(function (json){
            debugger
            state = json.message === "User is not autorize" ? false : true;
        })
        .catch(e => {
            console.error(e);
        });
    return state;
}

export const Login = async(data) =>{
    debugger
    let state
    let response = await fetch("http://localhost:5000/api/Account/Login", {
        method: 'Post',
        headers: {
          'Accept' : 'application/json',
          'Content-Type' : 'application/json'
        },
        body: data
    });
    debugger
    let jsom = await response.json();
}