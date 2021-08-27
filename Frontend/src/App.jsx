import logo from './logo.svg'
import './App.css'
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import 'bootstrap/dist/css/bootstrap.css'
import 'font-awesome/css/font-awesome.min.css'
import ReservationForm from './components/pages/reservationForm'
import React, { Component } from 'react'

class App extends Component {
  state = {}
  render() {
    return (
      <div className="App">
        <BrowserRouter>
          <main className="mt-5">
            <Switch>
              <Route path="/" exact component={ReservationForm}></Route>
            </Switch>
          </main>
        </BrowserRouter>
      </div>
    )
  }
}

export default App
