import axios from "axios"

let service = "https://localhost:5001"
// service = "http://localhost:5000"

type Result = {
    success: boolean
}

class Api {
    static async newKeyPress(event: KeyboardEvent) {
        const url = `${service}/api/tracking/newKeyPress`
        return await axios.post<Result>(url, {
            keyCode: event.keyCode,
            key: event.key
        })
    }
    static async newMouseMove(event: MouseEvent) {
        const url = `${service}/api/tracking/newMouseMove`
        return await axios.post<Result>(url, {
            clientX: event.clientX,
            clientY: event.clientY
        })
    }
}

document.addEventListener("mousemove", async e => {
    var rs = await Api.newMouseMove(e)
    // console.log(rs.data);
})

document.addEventListener("keypress", async e => {
    var rs = await Api.newKeyPress(e)
    // console.log(rs.data);
})