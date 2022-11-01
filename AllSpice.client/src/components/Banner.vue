<template>
  <div class="container-fluid banner">

    <div class="row">
      <div class="d-flex justify-content-end">
        <SearchBar />
        <span class="ms-4 mt-2">
          <Login />
        </span>
      </div>
    </div>
    <div class="row">
      <div class="col-md d-flex justify-content-center mt-4">
        <h2 class="neonText">Tri's Diner</h2>
      </div>
    </div>
    <div class="row">
      <div class="col-md d-flex justify-content-center">
        <h5 class="">...And Everything Nice</h5>
      </div>
    </div>

  </div>
  <div class="d-flex justify-content-center">
    <div class="col-md-4 bg-white d-flex justify-content-center buttonbar elevation-5">
      <div class="mt-2">
        <button class="btn ms-3 fs-4" @click="getAllRecipes()">HOME</button>
        <button class="btn ms-3 fs-4" @click="getAccountRecipes()">MY RECIPES</button>
        <button class="btn ms-3 me-3 fs-4" @click="getAccountFavorites()">FAVORITES</button>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from "../AppState.js";
import { accountService } from "../services/AccountService.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";


export default {
  setup() {
    return {
      async getAccountFavorites() {
        try {
          AppState.number = 1
          await accountService.getAllFavorites();
        } catch (error) {
          Pop.error(error, "[getFavoriteRecipes]");
        }
      },
      async getAllRecipes() {
        try {
          AppState.number = 0
          await recipesService.getAllRecipes();
        } catch (error) {
          Pop.error(error, "[getFavoriteRecipes]");
        }
      },
      async getAccountRecipes() {
        try {
          AppState.number = 0
          await recipesService.getAccountRecipes();
        } catch (error) {
          Pop.error(error);
        }
      },
    }
  }
}
</script>


<style lang="scss" scoped>
.banner {
  background-image: URL(https://images.unsplash.com/photo-1486485764572-92b96f21882a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1674&q=80);
  background-size: cover;
  background-position: bottom;
  background-attachment: fixed;
  height: 450px;
  position: relative;
  object-fit: cover;
}

.buttonbar {
  transform: translateY(-2.5rem) translateX(.5rem);
  position: absolute;
  min-height: 70px;
  min-width: 250px;
}

.neonText {
  color: #fff;
  text-shadow:
    0 0 7px #fff,
    0 0 10px #fff,
    0 0 21px rgb(246, 11, 11),
    0 0 42px rgb(255, 102, 0),
    0 0 82px rgb(255, 230, 0),
    0 0 92px rgb(255, 98, 0),
    0 0 102px rgb(225, 255, 0),
    0 0 151px rgb(255, 238, 0);
}
</style>