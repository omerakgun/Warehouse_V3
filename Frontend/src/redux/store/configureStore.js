import { createStore, combineReducers } from "redux";
import shoppingCartReducer from "../reducers/shoppingCartReducers";
const rootReducer = combineReducers({ shoppingCartState: shoppingCartReducer });
const configureStore = () => {
  return createStore(rootReducer);
};
export default configureStore;
