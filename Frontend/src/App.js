import logo from './logo.svg';
import './App.css';
import Navbar from './components/navbar';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import CarList from './pages/carlist';
import WarehouseList from './pages/warehouselist';
import CarDetail from './pages/cardetail';
import ShoppingCart from './pages/shoppingcart';

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path='/carlist' element={<CarList/>}/>
        <Route path='/warehouselist' element={<WarehouseList/>} />
        <Route path='/shoppingcart' element={<ShoppingCart/>} />
        <Route path='/cardetail' element={<CarDetail/>} />
      </Routes>
    </Router>
  );
}

export default App;
