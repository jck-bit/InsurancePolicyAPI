using InsurancePolicyAPI.Data;
using InsurancePolicyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PolicyController : ControllerBase
{
    private static readonly string[] AllowedTypes = { "Life", "Health", "Vehicle", "Universal Life" };

    private readonly PolicyContext _context;

    public PolicyController(PolicyContext context)
    {
        _context = context;
    }

    // GET: api/Policy
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies()
    {
        return await _context.Policies.ToListAsync();
    }

    // GET: api/Policy/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Policy>> GetPolicy(int id)
    {
        var policy = await _context.Policies.FindAsync(id);

        if (policy == null)
        {
            return NotFound();
        }

        return policy;
    }

    // POST: api/Policy
    [HttpPost]
    public IActionResult CreatePolicy([FromBody] Policy policy)
    {
        // Check model validation
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Validating the policy type
        if (!AllowedTypes.Contains(policy.Type, StringComparer.OrdinalIgnoreCase))
        {
            return BadRequest("Invalid policy type. Allowed types are: Life, Health, Vehicle, Universal Life.");
        }

        _context.Policies.Add(policy);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetPolicy), new { id = policy.Id }, new { message = "Policy created successfully.", policy });
    }

    // PUT: api/Policy/{id}
    [HttpPut("{id}")]
    public IActionResult UpdatePolicy(int id, [FromBody] Policy policy)
    {
        // Check model validation
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Validate policy type
        if (!AllowedTypes.Contains(policy.Type, StringComparer.OrdinalIgnoreCase))
        {
            return BadRequest("Invalid policy type. Allowed types are: Life, Health, Vehicle, Universal Life.");
        }

        var existingPolicy = _context.Policies.Find(id);
        if (existingPolicy == null)
        {
            return NotFound();
        }

        existingPolicy.Name = policy.Name;
        existingPolicy.Type = policy.Type;
        existingPolicy.Premium = policy.Premium;
        existingPolicy.Coverage = policy.Coverage;

        _context.SaveChanges();

        return Ok(new { message = "Policy updated successfully.", policy = existingPolicy });
    }

    // DELETE: api/Policy/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePolicy(int id)
    {
        var policy = await _context.Policies.FindAsync(id);

        if (policy == null)
        {
            return NotFound();
        }

        _context.Policies.Remove(policy);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Policy deleted successfully." });
    }

    private bool PolicyExists(int id)
    {
        return _context.Policies.Any(e => e.Id == id);
    }
}
