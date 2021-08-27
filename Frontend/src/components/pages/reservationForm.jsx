import React, { Component } from 'react'
import Form from '../common/form'
import Joi from 'joi'
import { Container } from 'react-bootstrap'
import axios from 'axios'
import config from '../../config.json'

class RegisterForm extends Form {
  state = {
    data: {
      name: '',
      email: '',
      country: '',
      adults: 0,
      children: 0,
      roomType: 0,
      mealPlan: 0,
      checkIn: null,
      checkOut: null,
    },
    meals: [],
    rooms: [],
    errors: [],
    globalError: '',
    globalOK: '',
  }

  getTomorrow() {
    const tomorrow = new Date(Date.now())
    tomorrow.setDate(tomorrow.getDate() + 1)
    return tomorrow
  }
  apiEndPoint = config.apiEndPoint + 'hotels'

  schema = Joi.object({
    name: Joi.string().required().max(50).min(4).label('Name'),
    email: Joi.string().required().max(50).min(4).label('Email'),
    country: Joi.string().required().max(20).min(4).label('Country'),
    adults: Joi.number().required().max(2).min(1).label('Adults'),
    children: Joi.number().required().max(2).min(0).label('Children'),
    roomType: Joi.number().label('Room Type').min(1),
    mealPlan: Joi.number().label('Meal Plan').min(1),
    checkIn: Joi.date().required().label('Check-in Date'),
    checkOut: Joi.date().required().label('Checkout date'),
  })
  async componentDidMount() {
    try {
      const result = await axios.get(this.apiEndPoint)
      if (result.status == 200) {
        const meals = result.data.value.meals
        const rooms = result.data.value.rooms
        this.setState({
          rooms,
          meals,
          errors: [],
        })
      }
    } catch (ex) {
      console.log(ex.response)
      this.setState({
        globalError: 'Couldnt load the data from the server',
        globalOK: '',
      })
    }
  }
  validateDates() {
    const { checkOut, checkIn } = this.state.data
    return checkOut > checkIn
  }
  async doSubmit() {
    try {
      if (!this.validateDates()) {
        this.setState({
          globalError: 'Check out date must be after check in date.',
          globalOK: '',
        })
        return
      }
      const result = await axios.post(this.apiEndPoint, this.state.data)
      console.log(this.state.data)
      if (result.status == 200) {
        this.setState({
          globalOK: `Total Reservation fees: ${result.data} USD`,
          globalError: '',
        })
        console.log(this.state.data)
      }
    } catch (ex) {
      console.log(ex.response)
      this.setState({
        globalError: 'Input data is invalid',
        globalOK: '',
      })
    }
  }

  render() {
    const { globalError, globalOK } = this.state
    return (
      <Container>
        <h3 className="mb-5">Reservation</h3>
        {this.renderInput('name', 'Name')}
        {this.renderInput('email', 'Email')}
        {this.renderInput('country', 'Country')}
        {this.renderInput('adults', 'Adults')}
        {this.renderInput('children', 'Children')}
        {this.renderDropdown('roomType', 'Room Type', this.state.rooms)}
        {this.renderDropdown('mealPlan', 'Meal Plan', this.state.meals)}
        {this.renderDatePicker('checkIn', 'Check-in date')}
        {this.renderDatePicker('checkOut', 'Check-out date')}
        {this.renderBtn('Get total reservation amount')}
        {globalError && (
          <div className="mt-3 alert alert-danger">{globalError}</div>
        )}
        {globalOK && <div className="mt-3 alert alert-success">{globalOK}</div>}
      </Container>
    )
  }
}

export default RegisterForm
