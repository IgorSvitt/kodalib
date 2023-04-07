<template>
  <header>
    <div class="container">
      <nav class="nav">
        <button class="menu-btn" @click="toggleMenu">
          <img src="@/assets/NavbarImage/menu.svg" alt="Меню" class="menu-img" :class="{ 'menu-open': isMenuOpen }">
        </button>
        <div class="menu-dropdown" :class="{ 'menu-open': isMenuOpen }">
          <a href="/" class="menu-item">Главная</a>
          <a href="/series" class="menu-item">Дорамы</a>
          <a href="/films" class="menu-item">Фильмы</a>
        </div>
        <a href="/" class="title-kodalib"> KODALIB </a>
        <div class="menu-kodalib">
          <a href="/series" class="dramas">Дорамы</a>
          <a href="/films" class="films">Фильмы</a>
        </div>

        <form action="/series" class="search-bar">
          <input type="text" placeholder="Поиск..." name="q" v-model="query"/>
          <button type="submit" class="search-btn">
            <img src="@/assets/NavbarImage/search.svg" class="search-img"/>
          </button>
        </form>
      </nav>
    </div>
  </header>
</template>

<script>
import {ref} from "vue";

export default {
  name: "KodaNavbar",
  setup() {

    const isMenuOpen = ref(false);
    const query = ref("");
    const querySmall = ref("");

    const toggleMenu = () => {
      isMenuOpen.value = !isMenuOpen.value;
    };

    return {
      isMenuOpen,
      toggleMenu,
      query,
      querySmall
    };
  },
};
</script>


<style scoped>

header {
  background-color: #4e3883;
  height: 75px;
}

a:hover {
  color: #ffddcc;
  transition: color .3s ease;
}

.nav {
  font-size: 18px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  text-align: left;
}

.menu-kodalib{
  flex: 1;
  text-align: center;
  display: flex;
  text-align: left;
}

.title-kodalib {
  color: #efefef;
  font-size: 40px;
  font-weight: 700;
  line-height: 75px;
  width: 200px;
  text-align: left;
}

.dramas, .films, .menu-item {
  color: #efefef;
  width: 100px;
}



/* Search */
.search-bar {
  width: 420px;
  height: 30px;
  display: flex;
  align-items: center;
  background: rgba(255, 255, 255, 0.16);
  border-radius: 9px;
  padding: 5px;
  font-size: 18px;
}

input.large{
  display: inline-block;
}

input.small{
  display: none
}

.search-bar input {
  background: transparent;
  flex: 1;
  border: 0;
  outline: none;
  padding-left: 15px;
  opacity: 1;
  color: #efefef;
}

.search-bar button {
  border: 0;
  background: none;
  color: #1b132e;
  cursor: pointer;
}

.search-img {
  width: 20px;
  height: 20px;
  transition: all .3s ease;
}

.search-img:hover {
  width: 25px;
  height: 25px;
  transition: all .3s ease;
}

.search-btn {
  display: flex;
  padding-right: 5px;
}


.menu-btn {
  display: none;
  background-repeat: no-repeat;
  background-position: center;
  width: 30px;
  height: 30px;
  cursor: pointer;
  background: none;
}

.menu-kodalib {
  position: relative;
}

.menu-img{
  height: 100%;
  width: 100%;
}


.menu-dropdown {
  position: absolute;
  top: 70px;
  left: 0;
  z-index: 1;
  display: none;
  width: 100%;
  background-color: #4e3883;
  align-items: center;
}

.menu-open {
  display: block;
}

.menu-item {
  display: block;
  padding: 10px 0;
  text-align: center;
  text-decoration: none;
  font-size: 16px;
  color: #efefef;
  width: 100%;
}

.menu-item:hover {
  background-color: #4e3883;
}

.menu-dropdown.menu-open{
  display: none;
}

@media (max-width: 1000px){
  .nav {
    font-size: 16px;
  }
  .title-kodalib {
    font-size: 35px;
  }
  .search-bar {
    width: 320px;
  }
}

@media (max-width: 752px) {
  .title-kodalib {
    font-size: 32px;
    width: auto;
  }
  .search-bar {
    width: 150px;
    height: 20px;
    font-size: 14px;
  }

  .menu-btn{
    display: inline-block;
    border: none;
  }

  input{
    display: inline-block;
    width: 100px;
  }


  .menu-kodalib {
    display: none;
  }

  .menu-dropdown.menu-open{
    display: block;
  }

}

.menu-dropdown {
  position: absolute;
  top: 70px;
  left: 0;
  z-index: 1;
  opacity: 0;
  transform: translateY(-10px);
  animation: dropdown 0.3s ease forwards;
}

.menu-open {
  opacity: 1;
  transform: translateY(0);
}

@keyframes dropdown {
  from {
    opacity: 0;
    transform: translateY(-10px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

</style>