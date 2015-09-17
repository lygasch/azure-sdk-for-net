## \[Major.Minor.Patch\]
_Release date:_

### Breaking Changes


### Feature Additions
* New Activity type: AzureMLUpdateResource, along with a new property in the AzureML Linked Service, "managementEndpoint". 
This Activity takes as input a blob Dataset for an .iLearner file (e.g. produced as output of a retraining batch execution)
and uploads it to the indicated management endpoint.


### Bug Fixes
