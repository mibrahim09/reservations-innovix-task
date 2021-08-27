import React, { Component } from 'react'
import Input from './input'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'

class Form extends Component {
  state = {
    data: {},
    errors: {},
  }

  validate = () => {
    const { data } = this.state

    const joiResult = this.schema.validate(data, {
      abortEarly: false,
    })
    if (!joiResult.error) {
      return null
    } // empty errors
    const errors = this.state.errors
    joiResult.error.details.forEach((element) => {
      errors[element.path] = element.message
    })
    return errors
  }

  validateProperty = (input) => {
    const { name, value } = input
    return this.realValidateProperty(name, value)
  }

  realValidateProperty = (name, value) => {
    const customSchema = this.schema.extract(name) // extract the schema i need.

    const joiResult = customSchema.validate(value)
    if (joiResult.error) return joiResult.error.message
  }

  validateDateProperty = (name, value) => {
    const customSchema = this.schema.extract(name) // extract the schema i need.

    const joiResult = customSchema.validate(value)
    if (joiResult.error) return joiResult.error.message
  }

  handleSubmit = (e) => {
    e.preventDefault() // to prevent the submission of the form!

    const errors = this.validate()

    this.setState({ errors: errors || [] })
    if (errors) return

    this.doSubmit()
  }

  handleChange = (e) => {
    const input = e.currentTarget
    const error = this.validateProperty(input)
    const errors = [...this.state.errors]
    if (error) errors[input.name] = error
    else delete errors[input.name]

    const data = { ...this.state.data } // clone the old.
    data[input.name] = input.value // get the currentInput and get the name to set its value.
    this.setState({ data: data, errors: errors })
  }
  formatDate(date) {
    return date.toLocaleDateString('en-US')
  }
  handleDropdownChange = (e) => {
    const name = e.target.name
    const value = e.target.value

    const error = this.realValidateProperty(name, value)
    const errors = [...this.state.errors]
    if (error) errors[name] = error
    else delete errors[name]

    const data = { ...this.state.data } // clone the old.
    data[name] = value // get the currentInput and get the name to set its value.
    this.setState({ data: data, errors: errors })
  }

  handleDatePicker = (date, name) => {
    const error = this.validateDateProperty(name, date)

    const errors = [...this.state.errors]
    if (error) errors[name] = error
    else delete errors[name]

    const data = { ...this.state.data } // clone the old.
    data[name] = date // get the currentInput and get the name to set its value.
    this.setState({ data: data, errors: errors })
  }

  renderBtn = (label) => {
    return (
      <button
        type="submit"
        disabled={this.validate()}
        className="btn btn-primary"
        onClick={this.handleSubmit}
      >
        {label}
      </button>
    )
  }
  renderInput = (name, label, type = 'text', placeholder = '') => {
    return (
      <Input
        label={label}
        type={type}
        value={this.state.data[name]}
        onChange={this.handleChange}
        placeholder={placeholder}
        error={this.state.errors[name]}
        name={name}
      ></Input>
    )
  }
  renderDropdown = (name, label, items) => {
    const error = this.state.errors[name]
    return (
      <div className="mb-3">
        <label htmlFor={name} className="form-label mb-3">
          {label}
        </label>
        <select
          name={name}
          className="form-select"
          onChange={this.handleDropdownChange}
        >
          <option key="0" disabled selected>Select..</option>{' '}
          {items.map((a) => (
            <option value={a.id} key={a.id}>
              {a.value}
            </option>
          ))}
        </select>
        {
          // {...rest} extracts the types without adding them manually.
        }
        {error && <div className="alert alert-danger">{error}</div>}
      </div>
    )
  }
  renderDatePicker = (name, label) => {
    const error = this.state.errors[name]
    return (
      <div className="mb-3">
        <label htmlFor={name} className="form-label mb-3">
          {label}
        </label>
        <DatePicker
          name={name}
          selected={this.state.data[name]}
          onSelect={(date) => this.handleDatePicker(date, name)}
        ></DatePicker>
        {error && <div className="alert alert-danger">{error}</div>}
      </div>
    )
  }
}

export default Form
