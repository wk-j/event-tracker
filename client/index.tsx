import React from "react"
import ReactDOM from "react-dom"
import { hubConnection } from "./hub";

import "./style.css"

type State = {
    clientX: number
    clientY: number
    key: string
}

class App extends React.Component<{}, State> {
    constructor(props) {
        super(props);

        this.state = {
            clientX: 0,
            clientY: 0,
            key: "#"
        }

        hubConnection.on("mouseMove", (event) => {
            this.setState({
                clientX: event.clientX,
                clientY: event.clientY
            })
        })

        hubConnection.on("keyPress", (event) => {
            const key: string = event.key;
            this.setState({
                key: key.trim() === "" ? ":)" : key
            })
        })
    }

    public render() {
        return (
            <div style={{ width: "500px", marginRight: "auto", marginLeft: "auto", textAlign: "center" }}>
                <div className="key">{this.state.key}</div>
                <div className="client">({this.state.clientX}, {this.state.clientY})</div>
            </div>
        )
    }
}

const el = document.getElementById("root")
ReactDOM.render(<App />, el)