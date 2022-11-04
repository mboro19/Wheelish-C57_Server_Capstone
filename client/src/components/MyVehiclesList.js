import React, { useEffect, useState } from "react";
import { getAllVehicles } from "../modules/vehicleManager";
import { Card, CardBody} from "reactstrap";
import {Link} from 'react-router-dom';
import { deleteVehicle } from "../modules/vehicleManager";


const VehicleList = () => {
  const [vehicles, setVehicles] = useState([]);

  const getVehicles = () => {
    getAllVehicles().then((vehicle) => setVehicles(vehicle));
  };

  useEffect(() => {
    getVehicles();
  });

  return (
    <div className="container">
      <div className="row justify-content-center">
        <h3>This is a list of vehicles in my inventory...</h3>

        {vehicles.map((vehicle) => (
              <Card key={vehicle.id}>
              <CardBody>
                <p><b>Make:</b> {vehicle.vehicleMake}</p>
                <p><b>Model:</b> {vehicle.vehicleModel}</p>
                <p><b>Miles:</b> {vehicle.userVehicles.vehicleMiles}</p>
                <p><b>Cost:</b> ${vehicle.userVehicles.vehicleCost}</p>
                <p><b>Year:</b> {vehicle.vehicleYear}</p>
                <div>
                <Link to= {`/VehicleEdit/${vehicle.id}`}>Edit Vehicle</Link>
                </div>
                <div>
                <Link onClick={()=>{deleteVehicle(vehicle.id)}} >Delete Vehicle</Link>
                </div>
        {/* <Button onClick={navigate(`/VehicleEdit/${vehicle.id}`)}>Edit</Button> */}                
              </CardBody>
            </Card>
          // <Vehicles vehicle={vehicle} key={vehicle.id} />
        ))}
      </div>
    </div>
  );
};
export default VehicleList;
