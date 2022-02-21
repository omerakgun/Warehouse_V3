import {
  ADD_SHOPPING_CART,
  DELETE_SHOPPING_CART,
  CLEAR_SHOPPING_CART,
} from "../constants/index";

const initialState = {
  shoppingCartItems: [],
};

const shoppingCartReducer = (state = initialState, action) => {
  switch (action.type) {
    case ADD_SHOPPING_CART:
      return {
        ...state,
        shoppingCartItems: [...state.shoppingCartItems, action.payload],
      };
    case DELETE_SHOPPING_CART:
      let shoppingCartItemsPrev = Object.assign(state.shoppingCartItems);
      for (let index in shoppingCartItemsPrev) {
        let shoppingCartItem = shoppingCartItemsPrev[index];
        if (shoppingCartItem.carID == action.payload) {
          shoppingCartItemsPrev.splice(index, 1);
          break;
        }
      }
      return {
        ...state,
        shoppingCartItems: shoppingCartItemsPrev,
      };
    case CLEAR_SHOPPING_CART:
      return {
        ...state,
        shoppingCartItems: [],
      };
    default:
      return state;
  }
};
export default shoppingCartReducer;
