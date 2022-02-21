import React from "react";
import { useNavigate } from "react-router-dom";

function CarItem(props) {
  const navigate = useNavigate();

  const goDetail = function () {
    navigate("/cardetail", { state : {carItem : props.car}});
  };

  return (
    <div
      style={{
        display: "flex",
        borderWidth: 1,
        borderColor: "black",
        marginTop: 3,
      }}
    >
      <div style={{ width: "10%" }}>{props.car.make}</div>
      <div style={{ width: "10%" }}>{props.car.model}</div>
      <div style={{ width: "10%" }}>{props.car.yearModel}</div>
      <div style={{ width: "10%" }}>&#8364;{props.car.price}</div>
      <div style={{ width: "10%" }}>{props.car.location}</div>
      <div style={{ width: "10%" }}>
        {props.car.licensed ? "True" : "False"}
      </div>
      <div style={{ width: "10%" }}>{props.car.dateAdded}</div>
      <div style={{ width: "10%" }}>
        <button onClick={() => goDetail()}>Show Detail</button>
      </div>
    </div>
  );
}

export default CarItem;
