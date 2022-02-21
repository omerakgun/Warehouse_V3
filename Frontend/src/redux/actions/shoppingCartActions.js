import {
    ADD_SHOPPING_CART,
    DELETE_SHOPPING_CART,
    CLEAR_SHOPPING_CART,
  } from "../constants/index";

  export function addShoppingCart(carItem) {
    return {
      type: ADD_SHOPPING_CART,
      payload: carItem,
    };
  }
  
  export function deleteShoppingCart(carItem) {
    return {
      type: DELETE_SHOPPING_CART,
      payload: carItem,
    };
  }
  
  export function clearShoppingCart() {
    return {
      type: CLEAR_SHOPPING_CART,
      payload: [],
    };
  }