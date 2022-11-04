import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Form, FormGroup } from "reactstrap";
import { editVehicle, getVehicleById } from "../modules/vehicleManager";

export const VehicleEdit = () => {
  const { vehicleId } = useParams();

  const [updatedVehicle, setUpdatedVehicle] = useState({

    id: vehicleId,
    vehicleYear: null,
    vehicleMake: "",
    vehicleModel: "",
    bodyStyleId: null,
    userVehicles: {
      vehicleMiles: null,
      vehicleCost: null,

    },
  });

  // const [vehicleById, setVehicleById] = useState({})

  const navigate = useNavigate();

  const getVehicles = () => {
    getVehicleById(vehicleId).then((vehicle) => {
      setUpdatedVehicle({ ...vehicle });
      // setVehicleById(vehicle)});
    });
  };

  useEffect(() => {
    getVehicles(vehicleId);
  }, []);

  useEffect(() => {});

  const handleEditButtonClick = (vehicle) => {
     editVehicle(vehicle).then(navigate("/MyVehiclesList"));
  };

  return (
    <>
      <Form>
        <FormGroup>
          <fieldset>
            <div>
              <label htmlFor="VehicleYear">New Vehicle Year:</label>
              <input
                value={updatedVehicle.vehicleYear}
                type="VehicleYear"
                placeholder="Enter Vehicle Year..."
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.vehicleYear = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              />
              <label htmlFor="VehicleMake">Vehicle Make:</label>
              <input
                value={updatedVehicle.vehicleMake}
                type="VehicleMake"
                placeholder="Enter Vehicle Make..."
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.vehicleMake = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              />

              <label htmlFor="VehicleModel">Vehicle Model:</label>
              <input
                value={updatedVehicle.vehicleModel}
                type="VehicleModel"
                placeholder="Enter Vehicle Model..."
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.vehicleModel = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              />

              <label htmlFor="BodyStyleId">Body Style</label>
              <p></p>
              <select
                name="BodyStyleId"
                value={updatedVehicle.bodyStyleId}
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.bodyStyleId = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              >
                <option value={null}>Select One</option>
                <option value={1}>Car</option>
                <option value={2}>Truck</option>
                <option value={3}>SUV</option>
                <option value={4}>Van</option>
                <option value={5}>Other</option>
              </select>

              <label htmlFor="VehicleMiles">Vehicle Miles:</label>
              <input
                value={updatedVehicle.userVehicles.vehicleMiles}
                type="VehicleMiles"
                placeholder="Enter Vehicle Miles..."
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.userVehicles.vehicleMiles = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              />

              <label htmlFor="VehicleCost">Vehicle Cost:</label>
              <input
                value={updatedVehicle.userVehicles.vehicleCost}
                type="VehicleCost"
                placeholder="Enter Vehicle Cost..."
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.userVehicles.vehicleCost = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              />

              <button
                onClick={(e) => {e.preventDefault()
                  handleEditButtonClick(updatedVehicle);
                }}
              >
                Save
              </button>
              <button
                onClick={() => {
                  navigate("/MyVehiclesList");
                }}
              >
                Cancel
              </button>
            </div>
          </fieldset>
        </FormGroup>
      </Form>
    </>
  );
};

//............. OLD CODE ...................................................................................//
//==========================================================================================================//
// const [VehicleYear, setUpdatedVehicleYear] = useState();
// const [VehicleMake, setUpdatedVehicleMake] = useState();
// const [VehicleModel, setUpdatedVehicleModel] = useState();
// const [BodyStyleId, setUpdatedBodyStyleId] = useState();
// const [VehicleMiles, setUpdatedVehicleMiles] = useState();
// const [VehicleCost, setUpdatedVehicleCost] = useState();

// const registerClick = (e) => {
//   e.preventDefault();

//       const updatedVehicle = {
//       Id : VehicleId,
//       VehicleYear,
//       VehicleMake,
//       VehicleModel,
//       BodyStyleId,
//       UserVehicles : {VehicleMiles,
//       VehicleCost}

//     };
//     console.log(updatedVehicle)
//     if(updatedVehicle.bodyStyleId === null){alert("Please select a valid body style.")}else{
//     editVehicle(updatedVehicle).then(() => navigate("/"));}; //function imported from vehicleManager that sends request to api
// }
// return (
//   <Form onSubmit={registerClick}><div><h4><b>Edit Your Vehicle...</b></h4></div>
//     <fieldset>
//       <FormGroup>
//         <Label htmlFor="VehicleYear"><b>Vehicle Year</b>  </Label>
//         <Input
//           id="VehicleYear"
//           type="text"
//           onChange={(e) => setUpdatedVehicleYear(e.target.value)}
//         />
//       </FormGroup>
//       <FormGroup>
//         <Label htmlFor="VehicleMake"><b>Vehicle Make</b>  </Label>
//         <Input
//           id="VehicleMake"
//           type="text"
//           onChange={(e) => setUpdatedVehicleMake(e.target.value)}
//         />
//       </FormGroup>
//       <FormGroup>
//         <Label htmlFor="VehicleModel"><b>Vehicle Model</b>  </Label>
//         <Input
//           id="VehicleModel"
//           type="text"
//           onChange={(e) => setUpdatedVehicleModel(e.target.value)}
//         />
//       </FormGroup>
//       <FormGroup>
//         <Label for="BodyStyle"><b>Body Style</b></Label>
//         <p></p>
//         <select name="BodyStyle"
//           onChange={(e) => setUpdatedBodyStyleId(e.target.value)}>
//           <option value={null}>Select One</option>
//           <option value={1}>Car</option>
//           <option value={2}>Truck</option>
//           <option value={3}>SUV</option>
//           <option value={4}>Van</option>
//           <option value={5}>Other</option>
//         </select>

//       </FormGroup>
//       <FormGroup>
//         <Label htmlFor="VehicleMiles"><b>Vehicle Miles</b>  </Label>
//         <Input
//           id="VehicleMiles"
//           type="text"
//           onChange={(e) => setUpdatedVehicleMiles(e.target.value)}
//         />
//       </FormGroup>
//       <FormGroup>
//         <Label htmlFor="VehicleCost"><b>Vehicle Cost</b>  </Label>
//         <Input
//           id="VehicleCost"
//           type="text"
//           onChange={(e) => setUpdatedVehicleCost(e.target.value)}
//         />
//       </FormGroup>
//       <FormGroup>
//         <Button>Submit</Button>
//         <Button onClick={() => { navigate("/category") }}>Cancel</Button>
//       </FormGroup>
//     </fieldset>
//   </Form>
//======================================================================================================================================//
