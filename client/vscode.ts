import axios from "axios"

let service = "https://localhost:5001"
// service = "http://localhost:5000"

type Result = {
    success: boolean
}

class Api {
    public static async newKeyPress(event: KeyboardEvent) {
        const url = `${service}/api/tracking/keyPress`
        return await axios.post<Result>(url, {
            keyCode: event.keyCode,
            key: event.key
        })
    }
    public static async newMouseMove(event: MouseEvent) {
        const url = `${service}/api/tracking/mouseMove`
        return await axios.post<Result>(url, {
            clientX: event.clientX,
            clientY: event.clientY
        })
    }
}

document.addEventListener("mousemove", async e => {
    let rs = await Api.newMouseMove(e)
})

document.addEventListener("keypress", async e => {
    let rs = await Api.newKeyPress(e)
})