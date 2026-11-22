import { auth } from "@/lib/firebase";
import { onAuthStateChanged } from "firebase/auth";
import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const useAuthStore = defineStore('auth', () => {
    const user = ref(null)
    const ready = ref(null)
    const isAuthenticated = computed(() => !!user.value)

    const initialized = new Promise((resolve) => {
        onAuthStateChanged(auth, (u) => {
            user.value = u
            ready.value = true
            resolve()
        })
    })

    return {user, ready, isAuthenticated, initialized}
})