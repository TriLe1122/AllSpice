<template>
  <div class="component">
    <!-- Button trigger modal -->
    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
      Launch demo modal
    </button>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered modal-xl">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel"></h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body container" v-if="recipe">
            <div class="row">
              <div class="col-md-3" :style="{ backgroundImage: `url(${recipe.img})` }">
Lorem ipsum dolor, sit amet consectetur adipisicing elit. Impedit, consequuntur suscipit numquam odit commodi dicta itaque. Beatae, natus fugiat. Suscipit praesentium enim ipsum recusandae tenetur esse, atque cumque ex ullam!
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>


<script>

import { Recipe } from "../models/Recipe.js";

export default {
  props: {
    recipe: {
      type: Recipe,
    }
  },
  setup(props) {
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>