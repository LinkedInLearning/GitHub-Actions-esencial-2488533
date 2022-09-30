#!/bin/bash
set -e

api_url="https://swapi.dev/api/people/${INPUT_PERSON_ID}"

person_name=$(curl "${api_url}" | jq ".name")

echo "::set-output name=person_name::$person_name"