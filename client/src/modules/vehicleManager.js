import "firebase/auth";
import { getToken } from "./authManager";

const apiUrl = '/api/vehicles';

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
    return fetch(apiUrl, {
      method: "POST",
      headers:{
      "Content-Type": "application/json"},
      body: JSON.stringify(vehicle)
    })
    .then((res)=> {
      if(res.ok){
        return res.json()}
        else{
          throw new Error(
            "An unknown error occurred @ addVehicle."
          )
        }
    })
};
    