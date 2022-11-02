import React, { useEffect, useState } from "react";
import { getAllVehicles } from "../modules/vehicleManager";
import {Vehicles} from "./Vehicle";


const VehicleList = () => {
  const [vehicles, setVehicles] = useState([]);

  const getVehicles = () => {
    getAllVehicles().then(vehicle => setVehicles(vehicle));
  };

  useEffect(() => {
    getVehicles();
  }, []);

  return (
    <div className="container">
      <div className="row justify-content-center">
      <h3>This is a list of vehicles in my inventory...</h3>
        {vehicles.map((vehicle) => (
          <Vehicles vehicle={vehicle} key={vehicle.id} />



          
        ))}
      </div>
    </div>
  );
}
export default VehicleList;