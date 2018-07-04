import React from "react"
import ReactDOM from "react-dom"
import { hubConnection } from "./hub";

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
            key: ""
        }

        hubConnection.on("mouseMove", (event) => {
            this.setState({
                clientX: event.clientX,
                clientY: event.clientY
            })
        })
        hubConnection.on("keyPress", (event) => {
            this.setState({
                key: event.key
            })
        })

    }

    public render() {
        return (
            <div>
                <h1>{this.state.key}</h1>
                <h1>{this.state.clientX}</h1>
                <h1>{this.state.clientY}</h1>
            </div>
        )
    }
}

const el = document.getElementById("root")
ReactDOM.render(<App />, el)