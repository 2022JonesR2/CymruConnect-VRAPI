using JsonClasses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("/api/session")]
public class SessionController : ControllerBase {

    [HttpGet("IsSessionAvaliable")]
    public IActionResult GetSessionAvaliability() {

        string DeviceId = Request.Query["DeviceId"];

        if (string.IsNullOrEmpty(DeviceId)) {
            return StatusCode(400, JsonConvert.SerializeObject(new StandardResponse() {
                success = false,
                message = "Invalid Input Parameters",
                data = ""
            }));
        }

        if (DeviceAuthorisation.IsDeviceAuthorised(DeviceId)) {
            return StatusCode(401, JsonConvert.SerializeObject(new StandardResponse() {
                success = false,
                message = "Invalid Authorisation",
                data = "" // keep this empty for security I guess.
            }));
        }

        if (DeviceAuthorisation.IsTourOnline()) {
            return Ok(JsonConvert.SerializeObject(new StandardResponse() {
                success = true,
                message = "Tour Is Online.",
                data = ""
            }));
        }

        return Ok(JsonConvert.SerializeObject(new StandardResponse() {
            success = true,
            message = "Tour Is Offline",
            data = ""
        }));
    }
}