using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Stairways.Core.Utils;

namespace Stairways.Core.Models;

public class RoadmapJsonValidator
{
  private readonly static string _schema =
  @"{
    '$schema': 'http://json-schema.org/draft-07/schema#',
    'definitions': {
        'anchor': {
            'type': 'string',
            'enum': ['left', 'right', 'top', 'bottom']
        },
        'edge': {
            'required': [
                'id', 
                'startItemId', 
                'endItemId', 
                'startItemAnchor', 
                'endItemAnchor',
                'format',
                'style'],
            'properties': {
                'id': {
                    'type': 'string'    
                },
                'startItemId': {
                    'type': 'string'
                },
                'endItemId': {
                    'type': 'string'
                },
                'startItemAnchor': {
                    '$ref': '#/definitions/anchor'
                },
                'endItemAnchor': {
                    '$ref': '#/definitions/anchor'
                },
                'format': {
                    'type': 'string',
                    'enum': ['line', 'curve', 'straight']
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
                'signature',
                'label', 
                'labelWidth', 
                'labelSize',
                'width',
                'height', 
                'x',
                'y'],
            'properties': {
                'signature': {
                    'type': 'string'
                },
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
                x: {
                    'type': 'number'
                },
                y: {
                    'type': 'number'
                },
                width: {
                    'type': 'number'
                },
                height: {
                    'type': 'number'
                },
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
        'subTopic': {
            'allOf': [{'$ref': '#/definitions/item-base'}],
            'required': ['type'],
            'properties': {
                'type': {
                    'type': 'string',
                    'enum': ['subTopic']
                }
            }
        },
        'link': {
            'allOf': [{'$ref': '#/definitions/item-base'}],
            'required': ['type', 'linkTo'],
            'properties': {
                'linkTo': {
                    'type': 'string'
                },
                'type': {
                    'type': 'string',
                    'enum': ['link']
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
                {'$ref': '#/definitions/subTopic'},
                {'$ref': '#/definitions/link'},
                {'$ref': '#/definitions/text'}
            ]
        }
    },
    'required': ['edges', 'items'],
    'properties': {
        'edges': {
            'type': 'array',
            'minItems': 0,
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
        parsedSchema = JSchema.Parse(_schema);
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