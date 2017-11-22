import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Box from './box.js';

class App extends Component {
  constructor(props) {
    super(props)

    this.state = {
      grid: [[true, true, true],[false, false, false], [true, true, true]]
    }
  }

  render() {
    var boxes = [];
    for(var i = 0; i < 3; i++)
    {
      for(var j = 0; j < 3; j++)
      {
        boxes.push(<Box isBlue={this.state.grid[i][j]}/>);
      }
      boxes.push(<br />);
    }

    return (
      <div className="App" onClick={() => this.setState({grid: [[false, false, false],[true, true, true], [false, false, false]]})}>
        {boxes}
      </div>
    );
  }
}

export default App;

//[[true, true, false],[false, false, false], [true, true, true]]
