import React from "react"
import ReactDOM from "react-dom"
import "./css/style.css"
import { hubConnection } from "./hub";

type State = {
    clientX: number
    clientY: number
    words: string[]
    key: string
}

class App extends React.Component<{}, State> {
    constructor(props) {
        super(props);

        this.state = {
            clientX: 0,
            clientY: 0,
            words: ["~"],
            key: "~"
        }

        hubConnection.on("mouseMove", (event) => {
            this.setState({
                clientX: event.clientX,
                clientY: event.clientY
            })
        })

        hubConnection.on("keyPress", (event) => {
            const len = 50
            const key: string = event.key;
            let cwords = this.state.words;
            let newWords = [...cwords];
            if (cwords.length > len) {
                newWords = cwords.slice(cwords.length - len, cwords.length);
            }
            this.setState({
                words: [...newWords, key],
                key: key.trim() === "" ? ":)" : key
            })
        })
    }

    public render() {
        return (
            <div style={{ width: "1000px", marginRight: "auto", marginLeft: "auto", textAlign: "center" }}>
                <div className="key">{this.state.key}</div>
                <div className="word">{this.state.words.join("")}</div>
                <div className="client">({this.state.clientX}, {this.state.clientY})</div>
            </div>
        )
    }
}

const el = document.getElementById("root")
ReactDOM.render(<App />, el)