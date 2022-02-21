import React, { useState, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { connect, useStore } from "react-redux";
import { bindActionCreators } from "redux";
import { addShoppingCart,deleteShoppingCart,clearShoppingCart} from "../redux/actions/shoppingCartActions";

function CarDetail(props) {
  const navigate = useNavigate();
  const { state } = useLocation();
  const store = useStore();

  useEffect(() => {
    if (state == null) {
      navigate("/carlist");
    }
    console.log(state.carItem);
  });

  const addToShoppingCart = () => {
    props.actions.addShoppingCart(state.carItem);
    navigate("/carlist");
  }

  return (
    <>
      <div
        style={{
          width: "90%",
          marginLeft: "5%",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <h1>
          {state.carItem.make} {state.carItem.model} Car Detail
        </h1>
        <div>
          <b>CarID :</b> {state.carItem.carID}
        </div>
        <div style={{ marginTop: 5 }}>
          <b>Make :</b> {state.carItem.make}
        </div>
        <div style={{ marginTop: 5 }}>
          <b>Model :</b> {state.carItem.model}
        </div>
        <div style={{ marginTop: 5 }}>
          <b>Year Model :</b> {state.carItem.yearModel}
        </div>
        <div style={{ marginTop: 5 }}>
          <b>Car Location :</b> {state.carItem.location}
        </div>
        <div style={{ marginTop: 5 }}>
          <b>Date Added :</b> {state.carItem.dateAdded}
        </div>
        <div style={{ marginTop: 5 }}>
          <b>WarehouseID :</b> {state.carItem.warehouseID}
        </div>
        <div style={{ marginTop: 5 }}>
          <b>Warehouse Name :</b> {state.carItem.warehouseName}
        </div>
        <div style={{ marginTop: 5 }}>
          <b>Warehouse Location :</b> ({state.carItem.warehouseLocation.lat},
          {state.carItem.warehouseLocation.long})
        </div>
        <div style={{ marginTop: 5 }}>
          <b>Licensed : </b>
          {state.carItem.licensed ? "True" : "False"}
        </div>
        <div style={{ marginTop: 5 }}>
          <b>Price : &#8364;{state.carItem.price}</b>
        </div>
        <div style={{ marginTop: 5 }}>
          <button onClick={() => {addToShoppingCart()}}>Add Shopping Cart</button>
        </div>
      </div>
    </>
  );
}

const mapStateToProps = state => {
    return {
      shoppingCartState: state.shoppingCartState,
    };
  };
  
  const ActionCreators = Object.assign(
    {},
    {addShoppingCart, deleteShoppingCart, clearShoppingCart },
  );
  const mapDispatchToProps = dispatch => {
    return {actions: bindActionCreators(ActionCreators, dispatch)};
  };
  
  export default connect(mapStateToProps, mapDispatchToProps)(CarDetail);
