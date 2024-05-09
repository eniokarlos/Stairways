
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Stairways.Core.Utils;

namespace Stairways.Core.Models;

public class RoadmapJsonValidator
{
  private static string schema =
  @"{
    '$schema': 'http://json-schema.org/draft-07/schema#',
    'definitions': {
        'vector2': {
            'type': 'array',
            'description': 'Ponto no formato [x, y] ou [width, height]',
            'minItems': 2,
            'maxItems': 2,
            'items': {
                'type': 'number'
            }
        },
        'edge': {
            'required': ['start', 'end', 'format', 'style'],
            'properties': {
                'start': {
                    '$ref': '#/definitions/vector2'
                },
                'end': {
                    '$ref': '#/definitions/vector2'
                },
                'format': {
                    'type': 'string',
                    'enum': ['line', 'curve', 'straight'],
                    'default': 'line'
                },
                'style': {
                    'type': 'string',
                    'enum': ['solid', 'dashed', 'dotted'],
                    'default': 'solid'
                }
            },
            'additionalProperties': false
        },
        'content-link': {
            'required': ['text', 'url'],
            'properties': {
                'text': {
                    'type': 'string'
                },
                'url': {
                    'type': 'string'
                }
            },
            'additionalProperties': false
        },
        'item-content': {
            'required': ['title', 'description'],
            'properties': {
                'title': {
                    'type':'string'
                },
                'description':{
                    'type': 'string'
                },
                'links': {
                    'type': 'array',
                    'items': {
                        '$ref': '#/definitions/content-link'
                    }
                }
            },
            'additionalProperties': false
        },
        'item-base': {
            'required': [
                'label', 
                'labelWidth', 
                'labelSize',
                'position', 
                'dimension'],
            'properties': {
                'label': {
                    'type': 'string'
                },
                'labelWidth': {
                    'type': 'number'
                },
                'labelSize': {
                    'type': 'number'
                },
                'content': {
                    '$ref': '#/definitions/item-content'
                },
                'position': {
                    '$ref': '#/definitions/vector2'
                },
                'dimension': {
                    '$ref': '#/definitions/vector2'
                }
            }
        },
        'topic': {
            'allOf': [{'$ref': '#/definitions/item-base'}],
            'required': ['type'],
            'properties': {
                'type': {
                    'type': 'string',
                    'enum': ['topic']
                }
            }
        },
        'sub-topic': {
            'allOf': [{'$ref': '#/definitions/item-base'}],
            'required': ['type'],
            'properties': {
                'type': {
                    'type': 'string',
                    'enum': ['sub-topic']
                }
            }
        },
        'reference': {
            'allOf': [{'$ref': '#/definitions/item-base'}],
            'required': ['type', 'linkTo'],
            'properties': {
                'linkTo': {
                    'type': 'string'
                },
                'type': {
                    'type': 'string',
                    'enum': ['reference']
                }
            }
        },
        'text': {
            'allOf': [{'$ref': '#/definitions/item-base'}],
            'required': ['type'],
            'properties': {
                'type': {
                    'type': 'string',
                    'enum': ['text']
                }
            }
        },
        'item': {
            'anyOf': [
                {'$ref': '#/definitions/topic'},
                {'$ref': '#/definitions/sub-topic'},
                {'$ref': '#/definitions/reference'},
                {'$ref': '#/definitions/text'}
            ]
        }
    },
    'required': ['edges', 'items'],
    'properties': {
        'edges': {
            'type': 'array',
            'minItems': 1,
            'items': {
                '$ref': '#/definitions/edge'
            }
        },
        'items': {
            'type':'array',
            'minItems': 1,
            'items': {
                '$ref': '#/definitions/item'
            }
        }
    }
  }";


  public static Result<Errors.EntityValidationException> Parse(string json)
  {
    JSchema parsedSchema;
    JObject jsonObject;
    try{
        parsedSchema = JSchema.Parse(schema);
        jsonObject = JObject.Parse(json); 
    }
    catch
    {
        return Result<Errors.EntityValidationException>.Fail(new Errors.EntityValidationException("Invalid Json"));
    }

    if (!jsonObject.IsValid(parsedSchema)) 
      return Result<Errors.EntityValidationException>.Fail(new Errors.EntityValidationException("Invalid Json"));

    return Result<Errors.EntityValidationException>.Ok();
  }
}