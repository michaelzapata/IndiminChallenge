import { BFFClient } from "./BFFClient";
import { CitizenClient } from "./CitizenClient";
import { TaskingClient } from "./TaskingClient";

const servers = {
  citizenClient: new CitizenClient("http://localhost:8001"),
  taskingClient: new TaskingClient("http://localhost:8002"),
  bffClient: new BFFClient("http://localhost:8003")
};
export default {
  get: name => servers[name]
};
