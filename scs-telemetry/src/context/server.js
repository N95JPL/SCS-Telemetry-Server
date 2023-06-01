import React, { createContext, useState } from 'react'
export const ServerContext = createContext()
const ServerContextProvider = (props) => {
    var [Server, setServer] = useState({
        "Telemetry": false,
        "WebSocket": {
            "Active": false,
            "Port": 8080,
        },
        "Server": {
            "Active": false,
            "Port": 3100,
        },
        "Serial": {
            "Active": false,
            "Port": 3,
        }
    })
    return (
         <ServerContext.Provider 
            value={{
                Server
             }}>
               {props.children}
         </ServerContext.Provider>
    )
}
export default ServerContextProvider