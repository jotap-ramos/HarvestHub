using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class Contador
{
    public string Crc { get; set; } = null!;

    public int FuncionarioIdfuncionario { get; set; }

    public virtual Funcionario FuncionarioIdfuncionarioNavigation { get; set; } = null!;

    public virtual ICollection<Receita> Receita { get; set; } = new List<Receita>();
}