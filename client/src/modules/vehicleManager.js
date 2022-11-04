import "firebase/auth";
import { Alert } from "reactstrap";
import { getToken } from "./authManager";

const apiUrl = '/api/vehicles';



export const getVehicleById = (id) => {
  return getToken().then((token)=>{

    return fetch(apiUrl + `/getVehicleById/${id}`, {
      method: "GET",
      headers:{
        Authorization: `Bearer ${token}`,
      },
  })
  .then((res)=>{
    if(res.ok){
      return res.json();
    }else{
      throw new Error(
        "An error occurred at getVehicleById."
      )
    }
  })

  })
}

export const getAllVehicles = () => {
    return getToken().then((token) => {
      return fetch(apiUrl, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((resp) => {
        if (resp.ok) {
          return resp.json();
        } else {
          throw new Error(
            "An unknown error occurred @ getAllVehicles."
          )
        }
    })
  })
};

export const getVehiclesList = () => {

    return fetch(apiUrl + `/GetAll`, {
    method: "GET",
    })

  .then((res) => {
    if(res.ok){
    return res.json();}
    else{
      throw new Error(
        "An unknown error occurred @ getVehiclesList."
      )
    }
  })
};

export const addVehicle = (vehicle) => {
  return getToken().then((token) => {
    console.log(`THIS IS MY VEHICLE LN 70: ${JSON.stringify(vehicle)}`)
    return fetch(apiUrl, {
      method: "POST",
      headers:{
      Authorization: `Bearer ${token}`,
      "Content-Type": "application/json"},
      body: JSON.stringify(vehicle)
    })
    .then((res)=> {
      if(res.status === 401){
        
          throw new Error(
            "Not Authorized."
          )
        }else if(!res.ok){
          throw new Error(
            "An unknown error occurred @ add vehicle"
          )
        }
      })
  })  
}

export const editVehicle = (updatedVehicleObject) => {
  return getToken().then((token) => {
    return fetch(apiUrl + `/EditVehicle`, {
      method: "PUT",
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updatedVehicleObject),
    }).then((resp) => {
      if (resp.ok) {
        return 
      } else if (resp.status === 401) {
        throw new Error("Unauthorized");
      } else {
        throw new Error(
          "An unknown error occurred while trying to save the edited Vehicle.",
        );
      }
    });
  });
};

export const deleteVehicle = (id) => {
  return getToken().then((token => {
    return fetch (`${apiUrl}/DeleteVehicle/${id}`, {
      method: "DELETE",
      headers: {
        Authorization: `Bearer ${token}`
      },
    }).then((res)=>{
      if(res.ok){
        Alert("Successful")
      }else if(
        res.status === 401
      ){
        throw new Error("Unauthorized")
      }
        
      
      })
    }
  ))  
}
    