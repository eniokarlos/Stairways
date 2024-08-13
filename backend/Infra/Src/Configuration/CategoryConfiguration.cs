using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stairways.Core.Models;
using Stairways.Core.ValueObjects;

namespace Stairways.Infra.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
  public void Configure(EntityTypeBuilder<CategoryEntity> builder)
  {
    builder.ToTable("Categories"); 
    builder.HasKey(c => c.Id);
    builder.Property(c => c.Id)
      .HasConversion(
        id => id.Value,
        value => UUID4.Of(value).Unwrap()
      );
    
    builder.HasData(
      CategoryEntity.Of("Matemática").Unwrap(),
      CategoryEntity.Of("Estatística").Unwrap(),
      CategoryEntity.Of("Computação").Unwrap(),
      CategoryEntity.Of("Física").Unwrap(),
      CategoryEntity.Of("Química").Unwrap(),
      CategoryEntity.Of("Astronomia").Unwrap(),
      CategoryEntity.Of("Geociências").Unwrap(),
      CategoryEntity.Of("Oceanografia").Unwrap(),
      CategoryEntity.Of("Biologia Geral").Unwrap(),
      CategoryEntity.Of("Bioquímica").Unwrap(),
      CategoryEntity.Of("Biofísica").Unwrap(),
      CategoryEntity.Of("Farmacologia").Unwrap(),
      CategoryEntity.Of("Fisiologia").Unwrap(),
      CategoryEntity.Of("Genética").Unwrap(),
      CategoryEntity.Of("Imunologia").Unwrap(),
      CategoryEntity.Of("Microbiologia").Unwrap(),
      CategoryEntity.Of("Parasitologia").Unwrap(),
      CategoryEntity.Of("Botânica").Unwrap(),
      CategoryEntity.Of("Zoologia").Unwrap(),
      CategoryEntity.Of("Ecologia").Unwrap(),
      CategoryEntity.Of("Morfologia").Unwrap(),
      CategoryEntity.Of("Engenharia Civil").Unwrap(),
      CategoryEntity.Of("Engenharia Elétrica").Unwrap(),
      CategoryEntity.Of("Engenharia Mecânica").Unwrap(),
      CategoryEntity.Of("Engenharia Química").Unwrap(),
      CategoryEntity.Of("Engenharia de Produção").Unwrap(),
      CategoryEntity.Of("Engenharia de Materiais e Metalúrgica").Unwrap(),
      CategoryEntity.Of("Engenharia Sanitária").Unwrap(),
      CategoryEntity.Of("Engenharia Nuclear").Unwrap(),
      CategoryEntity.Of("Engenharia de Minas").Unwrap(),
      CategoryEntity.Of("Engenharia de Petróleo").Unwrap(),
      CategoryEntity.Of("Medicina").Unwrap(),
      CategoryEntity.Of("Odontologia").Unwrap(),
      CategoryEntity.Of("Enfermagem").Unwrap(),
      CategoryEntity.Of("Saúde Coletiva").Unwrap(),
      CategoryEntity.Of("Nutrição").Unwrap(),
      CategoryEntity.Of("Educação Física").Unwrap(),
      CategoryEntity.Of("Fonoaudiologia").Unwrap(),
      CategoryEntity.Of("Fisioterapia").Unwrap(),
      CategoryEntity.Of("Farmácia").Unwrap(),
      CategoryEntity.Of("Agronomia").Unwrap(),
      CategoryEntity.Of("Engenharia Florestal").Unwrap(),
      CategoryEntity.Of("Engenharia Agrícola").Unwrap(),
      CategoryEntity.Of("Medicina Veterinária").Unwrap(),
      CategoryEntity.Of("Zootecnia").Unwrap(),
      CategoryEntity.Of("Recursos Pesqueiros e Engenharia de Pesca").Unwrap(),
      CategoryEntity.Of("Ciência e Tecnologia de Alimentos").Unwrap(),
      CategoryEntity.Of("Administração").Unwrap(),
      CategoryEntity.Of("Ciências Contábeis").Unwrap(),
      CategoryEntity.Of("Ciências Econômicas").Unwrap(),
      CategoryEntity.Of("Comunicação").Unwrap(),
      CategoryEntity.Of("Direito").Unwrap(),
      CategoryEntity.Of("Serviço Social").Unwrap(),
      CategoryEntity.Of("Turismo").Unwrap(),
      CategoryEntity.Of("Arquitetura e Urbanismo").Unwrap(),
      CategoryEntity.Of("Planejamento Urbano e Regional").Unwrap(),
      CategoryEntity.Of("Demografia").Unwrap(),
      CategoryEntity.Of("Museologia").Unwrap(),
      CategoryEntity.Of("Filosofia").Unwrap(),
      CategoryEntity.Of("Sociologia").Unwrap(),
      CategoryEntity.Of("Antropologia").Unwrap(),
      CategoryEntity.Of("História").Unwrap(),
      CategoryEntity.Of("Geografia").Unwrap(),
      CategoryEntity.Of("Psicologia").Unwrap(),
      CategoryEntity.Of("Educação").Unwrap(),
      CategoryEntity.Of("Teologia").Unwrap(),
      CategoryEntity.Of("Ciência Política").Unwrap(),
      CategoryEntity.Of("Relações Internacionais").Unwrap(),
      CategoryEntity.Of("Linguística").Unwrap(),
      CategoryEntity.Of("Letras").Unwrap(),
      CategoryEntity.Of("Artes").Unwrap(),
      CategoryEntity.Of("Música").Unwrap(),
      CategoryEntity.Of("Teatro").Unwrap(),
      CategoryEntity.Of("Artes Visuais").Unwrap(),
      CategoryEntity.Of("Ciência e Tecnologia Ambiental").Unwrap(),
      CategoryEntity.Of("Ciência e Tecnologia dos Materiais").Unwrap(),
      CategoryEntity.Of("Interdisciplinar").Unwrap(),
      CategoryEntity.Of("Biotecnologia").Unwrap(),
      CategoryEntity.Of("Gastronomia").Unwrap()
    );
  }
}