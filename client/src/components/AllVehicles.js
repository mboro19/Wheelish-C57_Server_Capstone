import React, { useEffect, useState } from "react";
import { getAllVehicles, getVehiclesList } from "../modules/vehicleManager";
import {Vehicles} from "./Vehicle";


const AllVehicles = () => {
  const [vehicles, setVehicles] = useState([]);

  const getVehicles = () => {
    getVehiclesList().then(vehicle => setVehicles(vehicle));
  };

  useEffect(() => {
    getVehicles();
  }, []);

  return (
    <div className="container">
      <div className="row justify-content-center">
        <h3>This is a list of all vehicles available on Wheelish...</h3>
        {vehicles.map((vehicle) => (
          <Vehicles vehicle={vehicle} key={vehicle.id}></Vehicles>


          
        ))}
      </div>
    </div>
  );
}
export default AllVehicles;