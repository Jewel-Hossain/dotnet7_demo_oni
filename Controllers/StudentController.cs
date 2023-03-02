using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    //global member
    static List<Student> students = new List<Student>();

    public StudentController(){}//constructor


    [HttpGet("Get")]
    public IActionResult Get()
    {
        return Ok(students);
    }//func

    [HttpGet("GetById")]
    public IActionResult GetById(int id)
    {
        var student = students.Where(student => student._id == id).FirstOrDefault();
        if(student is null) return BadRequest($"Student with id = {id} isn't exist!");
        return Ok(student);
    }//func

    [HttpGet("GetByName")]
    public IActionResult GetByName(string name)
    {
        var student = students.Where(student => student.name == name).FirstOrDefault();
        if(student is null) return BadRequest($"Student with name = {name} isn't exist!");
        return Ok(student);
    }//func

    [HttpPost("Add")]
    public IActionResult Add(Student student)
    {
        students.Add(student);
        return Ok(student);
    }//func

    [HttpPut("Edit")]
    public IActionResult Edit(Student new_student)
    {
        var old_student = students.Where(student => student._id == new_student._id).FirstOrDefault();
        if(old_student is null) return BadRequest($"Student with name = {new_student.name} isn't exist!"); 
        old_student.name = new_student.name;
        return Ok(old_student);
    }//func

    [HttpDelete("Delete")]
    public IActionResult Delete(int id)
    {
        var student = students.Where(student => student._id == id).FirstOrDefault();
        if(student is null) return BadRequest($"Id = {id} isn't exist!"); 
        students.Remove(student);
        return Ok("Successful!");
    }//func


}//class
