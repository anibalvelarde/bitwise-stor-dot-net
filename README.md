# bitwise-stor-dot-net

A `dot.net`-based library for managing/storing up to 31 Boolean switches within an integer value. 

## Install
Using the `.NET Core` CLI
```
$ dotnet add package BitwiseStoreN
```

## Usage
### Simple cases:
`Pack()` & `Unpack()` with primitive value manipulation:
```csharp
using BitwiseStorN;

// intialize bitwise packager
var bws = new Operations();

// get integer value from boolean string 
int val = bws.pack('101');  // val = 5

// get a binary digit string (right-most-significant) from an integer
string bits = bws.unpack(val); // bits = "101"
```

### Array cases:
`PackArrayOf<T>()` & `UnpackArrayOf<T>()` with, you guessed it, `Array` types
```csharp
using BitwiseStorN;
var bws = new Operations();

// get integer value from array of bits string 
var val = bws.PackArrayOf<int>(new int[] {1, 0, 1});  // val = 5

// get integer value from array of bool values 
var val2 = bws.PackArrayOf<bool>(new bool[] {true, false, true});  // val = 5

// get a binary digit string (right-most-significant) from an integer
var bits = bws.UnpackArrayOf<int>(val); // bits = [1, 0, 1]
var bits = bws.unpackArrayOf<bool>(val); // bits = [true, false, true]
```

## Not Implemented yet...
### Object cases:
`Pack()` & `Unpack()` from a JSON object. The following requirements apply:
- only boolean properties get packed
- packing is shallow (no deep navigation of the object)
- only up to 31 values are packed
- the names of any packed properties are 64-bit encoded under the `BwsPackedPropNames` key
- the integer value of the packed bits is stored under the `BwsPackedValue` key
- the first boolean key is the most significant bit when packed

Example (using JS):
```js
const bws = require("@aevnpm/bitwise-stor");
const jsonObj = {
    name: 'Billy Russo',
    hasScars: true,
    canFeelLove: false,
    age: 38,
    cashOnHand: 4500,
    isHospitalized: false,
    isDeceased: false,
    heightInMeeters: 1.9,
    hasBankAccount: true
}

const packedObject = bws.packJson(jsonObj);
console.log({ packedObject })

// Console:
//  packedObject: {
//    name: 'Billy Russo',
//    age: 38,
//    cashOnHand: 4500,
//    heightInMeeters: 1.9,
//    bwsPackedPropNames: { ... 64-bit encoding ...},
//    bwsPackedValue: 17
//  } 

const unpackedObject = bws.unpackJson(packedObj);
console.log({ unpackedObject });

// Console:
//  packedObject: {
//    name: 'Billy Russo',
//    age: 38,
//    cashOnHand: 4500,
//    isDeceased: false,
//    heightInMeeters: 1.9,
//    hasScars: true,
//    canFeelLove: false,
//    isHospitalized: false,
//    isDeceased: false,
//    hasBankAccount: true
//  }
```