import React from "react"
import ReactDOM from "react-dom"
import "./css/style.css"
import { hubConnection } from "./hub";

type State = {
    clientX: number
    clientY: number
    words: string[]
    key: string
    summary: { [key: string]: number }
}

function pad(num, size = 4) { return ("000000000" + num).substr(-size); }

class App extends React.Component<{}, State> {
    constructor(props) {
        super(props);

        this.state = {
            clientX: 0,
            clientY: 0,
            words: ["~"],
            key: "~",
            summary: {}
        }

        hubConnection.on("mouseMove", (data) => {
            this.setState({
                clientX: data.clientX,
                clientY: data.clientY
            })
        })

        hubConnection.on("summary", (data) => {
            this.setState({
                summary: data.summary
            });
        });

        hubConnection.on("keyPress", (data) => {
            const len = 50
            const key: string = data.key
            let cwords = this.state.words;
            let newWords = [...cwords];
            if (cwords.length > len) {
                newWords = cwords.slice(cwords.length - len, cwords.length);
            }
            this.setState({
                words: [...newWords, key === "Enter" ? " " : data.key],
                key: key.trim() === "" ? ":)" : key
            })
        })
    }

    private renderSummary = () => {
        let alphabet = "abcdefghijklmnopqrstuvwxyz".split("");
        return alphabet.map(x => {
            return (
                <div key={x} style={{
                    display: "inline-block",
                    margin: "5px",
                    fontSize: "20px",
                    textAlign: "center"
                }}>
                    <div style={{
                        fontSize: "25px"
                    }}>{x}</div>
                    <div className="" style={{
                        marginTop: "10px",
                        fontSize: "15px",
                        fontWeight: "bolder"
                    }}>{this.state.summary[x] === undefined ? 0 : this.state.summary[x]}</div>
                </div>
            )
        })
    }

    public render() {
        return (
            <div style={{ width: "1100px", marginRight: "auto", marginLeft: "auto", textAlign: "center" }}>
                <div className="key">{this.state.key}</div>
                <div className="word">{this.state.words.join("")}</div>
                <div className="client">{pad(this.state.clientX)} ~ {pad(this.state.clientY)}</div>
                <div>
                    {this.renderSummary()}
                </div>
            </div>
        )
    }
}

const el = document.getElementById("root")
ReactDOM.render(<App />, el)